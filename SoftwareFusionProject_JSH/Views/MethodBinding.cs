using System;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Windows;
using System.Windows.Data;
using System.Windows.Markup;
using System.Windows.Media;
using Expression = System.Linq.Expressions.Expression;

// 뷰의 재믈파일에 xmlns선언을 해주어 확장마크업에 추가시킨다음
// 뷰의 이벤트에 추가시킨 확장마크업과 실행할 메소드 이름을 입력하고
// 뷰의 데이터 컨텍스트에 실행할 메소드가 있는 클래스를 할당한 다음
// 뷰의 이벤트를 발동시키면 연결된 메소드가 실행된다.
namespace SoftwareFusionProject_JSH.Views
{
    public class MethodBindingExtension : MarkupExtension // MarkupExtension으로 MethodBindingProvider의 Proxy Method를 생성
    {
        // 실행할 메소드 이름을 받습니다.
        public MethodBindingExtension(string method)
        {
            _method = method;
        }

        public MethodBindingExtension(string method, string datacontext)
        {
            _method = method;
            _datacontext = datacontext;
        }

        // 실행할 메소드 이름을 담습니다.
        private readonly string _method;

        private readonly string _datacontext = "@auto";

        // 뷰의 엘리먼트 객체를 뷰모델에 전달해줄 대리자를 선언합니다.
        public delegate void MethodProviderHandler(params object[] parameters);

        // 뷰 확장마크업에 추가된 클리스가 호출되면 실행되는 메소드.
        public override object ProvideValue(IServiceProvider serviceProvider)
        {
            // 뷰 확장마크업을 통해 전달받은 객체를 확인하기 위해 변환합니다.
            IProvideValueTarget provideValueTarget = serviceProvider as IProvideValueTarget;

            // ************************************************************************************************

            // 뷰에서 넘겨받은 이벤트 종류에 맞춰서 뷰모델에 전달할 이벤트를 생성합니다.
            // 뷰의 이벤트 타입에 맞게 언박싱해준다.
            object targetProperty = provideValueTarget.TargetProperty;
            Type memberType = null;

            if (targetProperty is DependencyProperty) // 의존속성인가?
            {
                memberType = (targetProperty as DependencyProperty).PropertyType;
            }

            if (targetProperty is MethodInfo) // 메소드상태인가?
            {
                ParameterInfo[] infos = (targetProperty as MethodInfo).GetParameters();
                memberType = infos[1].ParameterType;
            }

            if (targetProperty is EventInfo) // 이벤트상태인가?
            {
                memberType = (targetProperty as EventInfo).EventHandlerType;
            }

            if (targetProperty is PropertyInfo) // 속성상태인가?
            {
                memberType = (targetProperty as PropertyInfo).PropertyType;
            }

            // ************************************************************************************************

            // 뷰의 엘리먼트 객체를 뷰모델에 전달해줄 대리자를 정의합니다.
            // 뷰 확장마크업을 통해 전달받은 객체와 실행할 메소드 이름(경로)를 전달하여 뷰에서의 해당 데이타컨텍스트에서 엘리먼트 객체와 실행할 메소드 이름(경로)를 추출합니다.
            MethodBindingProvider provider = new MethodBindingProvider(provideValueTarget.TargetObject as FrameworkElement, _method, _datacontext);
            // 메소드를 호스팅하는 클래스를 대리자에 전달합니다.
            MethodProviderHandler handler = provider.MethodProviderHandler;

            // ************************************************************************************************

            // "이벤트" 매개 변수를 담는 컬렉션 : 언박싱된 타겟(이벤트)의 매개변수를 추출한다.
            ParameterInfo[] parameterInfos = memberType.GetMethod("Invoke").GetParameters();

            // 매개 변수 식. (매개변수 메타데이터에서 필요한 파라미터를 추출한다.)
            ParameterExpression[] parameters = new ParameterExpression[parameterInfos.Length];
            for (int i = 0; i < parameters.Length; i++)
            {
                parameters[i] = Expression.Parameter(parameterInfos[i].ParameterType, "x" + i);
            }

            // 매개 변수가 값타입인 경우 에러방지를 위해 변환해준다. 2020.12.04 ksh
            Expression[] indexExprs = new Expression[parameters.Length];
            for (var i = 0; i < indexExprs.Length; i++)
            {
                if (parameters[i].Type.IsValueType) // 값타입 매개변수... 구조체 등
                {
                    indexExprs[i] = Expression.Convert(parameters[i], typeof(object));
                }
                else
                {
                    indexExprs[i] = parameters[i];
                }
            }

            // 중간 전달 메소드(대리자)에 등록할 배열형태의 매개변수를 생성한다. (2배열 // 중간 메소드를 통해 뭉쳐진 매개변수가 전달된다.)
            NewArrayExpression arguments = Expression.NewArrayInit(typeof(object), indexExprs);

            // ************************************************************************************************

            // 정적 혹은 인스턴스 메소드
            // 호출할 메소드를 지정한다. (호출할 타겟, 대신 호출해줄 메소드이름 "Invoke", 전달될 매개변수)
            MethodCallExpression body = Expression.Call(Expression.Constant(handler), handler.GetType().GetMethod("Invoke"), new Expression[] { arguments });

            // 람다 식. (타겟을 호출해줄 대리자 생성 => 메소드, 전달될 매개변수)
            LambdaExpression lambda = Expression.Lambda(body, parameters);

            // ************************************************************************************************

            // 뷰의 객체와 이벤트를 전달하고 지정된 메소드를 실행합니다.
            return Delegate.CreateDelegate(memberType, lambda.Compile(), "Invoke", false);
        }
    }

    internal class MethodBindingProvider : DependencyObject // 대상 객체의 DataContext로부터 Method Path를 추출하여 메소드를 호스팅
    {
        // 메소드 정보
        private MethodInfo _methodInfo = null;
        // 매개변수 정보
        private ParameterInfo[] _parameters = null;
        // 메소드 이름
        private readonly string _methodName;

        // 뷰의 엘리먼트 객체와 엘리먼트 내에 데이타컨텍스트에서의 객체 경로를 담습니다.
        // 임의의 데이타 컨텍스트를 생성한다.
        public static readonly DependencyProperty DataContextProperty = DependencyProperty.Register("DataContext", typeof(object), typeof(MethodBindingProvider), new UIPropertyMetadata(null));

        // 객체와 이벤트를 초기화해주는애
        public MethodBindingProvider(FrameworkElement element, string methodPath, string datacontext) // 추출할 뷰의 엘리먼트 객체와 데이타컨텍스트 안의 객체 경로를 받습니다.
        {
            // 실행할 메소드이름 전달.
            _methodName = methodPath;

            if (datacontext != "@auto")
            {
                // 부모의 엘레먼트를 찾는다.
                DependencyObject parent = VisualTreeHelper.GetParent(element);

                for (int i = 0; i < 100; i++)
                {
                    // 타입을 검사한다.
                    FrameworkElement parentElement = parent as FrameworkElement;

                    if (parentElement != null && parentElement.DataContext != null)
                    {
                        string[] parentContext = parentElement.DataContext.ToString().Split('.');

                        if (parentContext[parentContext.Length - 1] == datacontext)
                        {
                            // DataContext를 추출한다.

                            // 바인딩 객체에 원본소스와 속성을 전달합니다. (뷰의 엘레먼트와 해당 클래스의 필드와 결합)
                            // 해당 클래스에 있는 임의의 데이타컨텍스트에 엘레먼트를 등록한다.
                            BindingOperations.SetBinding(this, DataContextProperty, new Binding { Source = parentElement, Path = new PropertyPath("DataContext") });
                            break;
                        }
                    }

                    if (parent == null)
                    {
                        break;
                    }

                    // 다시 부모의 부모의 엘레먼트를 찾는다.
                    parent = VisualTreeHelper.GetParent(parent);
                }
            }
            else
            {
                // 바인딩 객체에 원본소스와 속성을 전달합니다. (뷰의 엘레먼트와 해당 클래스의 필드와 결합)
                // 해당 클래스에 있는 임의의 데이타컨텍스트에 엘레먼트를 등록한다.
                BindingOperations.SetBinding(this, DataContextProperty, new Binding { Source = element, Path = new PropertyPath("DataContext") });
            }
        }

        // 프로그램이 실행될 때 동작합니다.
        // 뷰(xaml)를 통해 태그확장에 있는 메소드바인딩이 동작할 때 뷰모델의 메소드와 결합한다. (이전에 결합된 메소드가 있다면 삭제된다(Null 할당))
        protected override void OnPropertyChanged(DependencyPropertyChangedEventArgs e)
        {
            if (e.Property == DataContextProperty)
            {
                // 뷰의 엘레먼트와 결합된 해당 클래스의 필드안에 있는... => 메소드와 해당 클래스의 필드와 결합
                _methodInfo = GetValue(DataContextProperty) != null ? GetValue(DataContextProperty).GetType().GetMethod(_methodName) : null;

                // 뷰의 엘레먼트와 결합된 해당 클래스의 필드안에 있는... => 매개변수와 해당 클래스의 필드와 결합
                _parameters = _methodInfo != null ? _methodInfo.GetParameters() : null; // this._methodInfo가 Null이 아니면 할당.
            }
        }

        // 뷰모델의 메소드를 실행하는애
        internal void MethodProviderHandler(params object[] parameters)
        {
            if (_parameters != null) // 메소드 바인딩 문구에 오타가 있을 때 바인딩에 실패하여 프로그램이 종료되는 현상을 방지합니다.
            {
                try
                {
                    // Invoke 함수를 통해 뷰모델의 메소드를 호출합니다. (호출할 메소드 이름, 매개변수)
                    // 해당 클래스의 필드와 결합된 메소드 +
                    // 해당 클래스의 필드와 결합된 매개변수의 수 만큼 매개변수로 전달받는 파라미터 +
                    _methodInfo.Invoke(GetValue(DataContextProperty), parameters.Take(_parameters.Length).ToArray());
                }
                catch (Exception e)
                {
                    MessageBox.Show(e.Message);
                }
            }
        }
    }
}
