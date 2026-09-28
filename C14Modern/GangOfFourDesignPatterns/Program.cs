using GangOfFourDesignPatterns.Creational_Pattern;
using GangOfFourDesignPatterns.Structural_Patterns;
using GangOfFourDesignPatterns.Behavioral_Patterns;

namespace GangOfFourDesignPatterns
{
    public partial class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("---------- Structural Patterns");
            Console.WriteLine("Singleton");
            Singelton singleton = Singelton.Instance;
            Console.WriteLine($"nameOf: {nameof(singleton)} \ntype: {typeof(Singelton)} \nusefull call: {singleton.SomeUsefulMethod()}");
            Console.WriteLine();

            Console.WriteLine("Factory Method");
            // Usage
            Creator creator = new ConcreteCreatorA();
            Product product = creator.FactoryMethod();
            Console.WriteLine($"{product.GetType().Name}: {product.Operation()}");  // Outputs: ConcreteProductA
            creator = new ConcreteCreatorB();
            product = creator.FactoryMethod();
            Console.WriteLine($"{product.GetType().Name}: {product.Operation()}");  // Outputs: ConcreteProductB
            Console.WriteLine();

            Console.WriteLine("Abstract Factory");
            IGUIFactory factory = new WindowsFactory();
            factory.CreateButton().Render();  // Outputs: Rendering Windows Button
            factory.CreateCheckbox().Render();  // Outputs: Rendering Windows Checkbox
            IGUIFactory macFactory = new MacFactory();
            macFactory.CreateButton().Render();  // Outputs: Rendering Mac Button
            macFactory.CreateCheckbox().Render();  // Outputs: Rendering Mac Checkbox
            Console.WriteLine("");

            Console.WriteLine("Builder");
            IBuilder builder = new ConcreteBuilder();
            Director director = new Director(builder);
            director.Construct();
            Building building = builder.GetProduct();
            Console.WriteLine($"{building.PartA}, {building.PartB}, {building.PartC}");
            Console.WriteLine("");

            Console.WriteLine("Prototype");
            Prototype original = new Prototype { Property = "Original" };
            Prototype clone = (Prototype)original.Clone();
            clone.Property = "Clone";
            Console.WriteLine(original.Property);  // Outputs: Original
            Console.WriteLine("");

            Console.WriteLine("---------- Structural Patterns");
            Console.WriteLine("Adapter");
            ITarget target = new Adapter();
            target.Request();  // Outputs: Specific Request
            Console.WriteLine("");

            Console.WriteLine("Bridge");
            Abstraction abstraction = new RefinedAbstraction(new ConcreteImplementorA());
            abstraction.Operation();  // Outputs: ConcreteImplementorA Operation
            abstraction = new RefinedAbstraction(new ConcreteImplementorB());
            abstraction.Operation();  // Outputs: ConcreteImplementorB Operation
            Console.WriteLine("");

            Console.WriteLine("Composite");
            Composite root = new Composite();
            root.Add(new Leaf("Leaf A"));
            root.Add(new Leaf("Leaf B"));
            Composite subComposite = new Composite();
            subComposite.Add(new Leaf("Leaf C"));
            root.Add(subComposite);
            root.Operation();
            Console.WriteLine("");

            Console.WriteLine("Decorator");
            IComponent component = new ConcreteComponent();
            IComponent decorator = new ConcreteDecorator(component);
            decorator.Operation();
            Console.WriteLine("");

            Console.WriteLine("Facade");
            Facade facade = new Facade();
            facade.Operation();
            Console.WriteLine("");

            Console.WriteLine("FlyWeight");
            FontFactory fontFactory = new FontFactory();

            // Get shared flyweight objects
            IFont font1 = fontFactory.GetFont("Arial");
            IFont font2 = fontFactory.GetFont("Times New Roman");

            // Set intrinsic state
            font1.SetSize(12);
            font1.SetStyle("Regular");
            font1.SetColor("Black");

            font2.SetSize(14);
            font2.SetStyle("Italic");
            font2.SetColor("Red");

            // Use flyweight objects
            font1.Display("Hello, Flyweight Pattern!");
            font2.Display("This is a demonstration.");

            // Both fonts share the same intrinsic state
            Console.WriteLine("");

            // Proxy
            Console.WriteLine("Proxy");
            ISubject proxy = new Proxy();
            proxy.Request();  // Outputs: Real Request (lazy loaded)
            Console.WriteLine("");

            Console.WriteLine("Behavioral Patterns");
            // Chain of Responsibility
            Console.WriteLine("Chain of Responsibility");
            Handler handler1 = new ConcreteHandlerA();
            Handler handler2 = new ConcreteHandlerB();
            handler1.SetNext(handler2);

            // Test the chain
            handler1.HandleRequest(5);   // Handled by A
            handler1.HandleRequest(15);  // Handled by B
            Console.WriteLine("");

            Console.WriteLine("Command");
            Light light = new();
            ICommand lightOn = new LightOnCommand(light);
            RemoteControl remote = new RemoteControl();
            remote.SetCommand(lightOn);
            remote.PressButton();  // Outputs: Light is ON
            Console.WriteLine("");

            // Interpreter
            Console.WriteLine("Interpreter");
            Context context = new();
            context.SetVariable("x", 5);
            context.SetVariable("y", 10);
            // Build expression tree for: x + (y + 3)
            IExpression expression = new AddExpression(
                new VariableExpression("x"),
                new AddExpression(new VariableExpression("y"), new NumberExpression(3))
            );

            int result = expression.Interpret(context);
            Console.WriteLine($"Result: {result}"); // Output: 18        
            Console.WriteLine("");

            // Iterator
            Console.WriteLine("Iterator");
            Aggregate aggregate = new Aggregate();
            foreach (var item in aggregate)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine("");

            // Mediator
            Console.WriteLine("Mediator");
            IChatMediator room = new ChatRoom();

            User alice = new ChatUser(room, "Alice");
            User bob = new ChatUser(room, "Bob");
            User charlie = new ChatUser(room, "Charlie");

            room.AddUser(alice);
            room.AddUser(bob);
            room.AddUser(charlie);

            alice.Send("Hello everyone!");
            Console.WriteLine("");

            // Memento
            Console.WriteLine("Memento");
            Originator originator = new Originator();
            Caretaker caretaker = new Caretaker();

            originator.State = "State1";
            caretaker.Memento = originator.Save();

            originator.State = "State2";
            originator.Restore(caretaker.Memento);
            Console.WriteLine($"Restored State: {originator.State}");
            Console.WriteLine("");

            // Observer
            Console.WriteLine("Observer");
            // Usage
            Subject subject = new Subject();
            ConcreteObserver observer1 = new ConcreteObserver();
            ConcreteObserver observer2 = new ConcreteObserver();
            subject.Attach(observer1);
            subject.Attach(observer2);
            subject.Notify("Update!");  // Outputs: Received: Update!
            Console.WriteLine("");

            // State
            Console.WriteLine("State");
            // Usage
            ContextState contextState = new ContextState(new ConcreteStateA());
            contextState.Request();  // Outputs: State A
            contextState.Request();  // Outputs: State B
            Console.WriteLine("");

            // Strategy
            Console.WriteLine("Strategy");
            // Usage
            ContextStrategy contextStrategy = new ContextStrategy(new ConcreteStrategyA());
            contextStrategy.Execute();  // Outputs: Strategy A
            contextStrategy = new ContextStrategy(new ConcreteStrategyB());
            contextStrategy.Execute();  // Outputs: Strategy B
            Console.WriteLine("");

            // Template Method
            Console.WriteLine("Template Method");
            // Usage
            AbstractClass template = new ConcreteClass();
            template.TemplateMethod();  // Outputs: ConcreteClass specific implementation
            Console.WriteLine("");

            // Visitor
            Console.WriteLine("Visitor");
            // Usage
            ObjectStructure visitor = new ObjectStructure();
            Element elementA = new ElementA();
            Element elementB = new ElementB();
            visitor.Add(elementA);
            visitor.Add(elementB);
            ConcreteVisitor concreteVisitor = new ConcreteVisitor();
            visitor.Accept(concreteVisitor);  // Outputs: Visited A, Visited B
            Console.WriteLine("");
        }
    }
 }
