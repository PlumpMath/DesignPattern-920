using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Decorator
{

    //定义
    //装饰者模式以对客户透明的方式动态地给一个对象附加上更多的责任，装饰者模式相比生成子类可以更灵活地增加功能。

    //装饰者模式的优缺点
    //优点：
    //装饰这模式和继承的目的都是扩展对象的功能，但装饰者模式比继承更灵活
    //通过使用不同的具体装饰类以及这些类的排列组合，设计师可以创造出很多不同行为的组合
    //装饰者模式有很好地可扩展性

    //缺点：
    //装饰者模式会导致设计中出现许多小对象，如果过度使用，会让程序变的更复杂。
    //并且更多的对象会是的差错变得困难，特别是这些对象看上去都很像。

    //使用场景
    //需要扩展一个类的功能或给一个类增加附加责任。
    //需要动态地给一个对象增加功能，这些功能可以再动态地撤销。
    //需要增加由一些基本功能的排列组合而产生的非常大量的功能
    class Program
    {
        static void Main(string[] args)
        {

            Phone iPhone = new ApplePhone();

            var iPhoneWithSticker = new Sticker(iPhone);
            iPhoneWithSticker.Print();

            var iPhoneWithAccessory = new Accessory(iPhone);
            iPhoneWithAccessory.Print();

            Console.ReadLine();
        }
    }

    /// <summary>
    /// 抽象构件（Phone）角色：给出一个抽象接口，以规范准备接受附加责任的对象。
    /// </summary>
    public abstract class Phone
    {
        public abstract void Print();
    }

    /// <summary>
    /// 具体构件（AppPhone）角色：定义一个将要接收附加责任的类。
    /// </summary>
    public class ApplePhone:Phone
    {
        public override void Print()
        {
            Console.WriteLine("I am a Apple Phone!");
        }
    }

    /// <summary>
    /// 装饰（Decorator）角色：持有一个构件（Component）对象的实例，并定义一个与抽象构件接口一致的接口。
    /// </summary>
    public class Decorator:Phone
    {
        private Phone _phone;

        public Decorator(Phone phone)
        {
            _phone = phone;
        }

        public override void Print()
        {
            if (_phone!=null)
            {
                _phone.Print();
            }            
        }
    }

    /// <summary>
    /// 具体装饰（Sticker和Accessories）角色：负责给构件对象 ”贴上“附加的责任。
    /// </summary>
    public class Sticker:Decorator
    {
        private Phone _phone;
        public Sticker(Phone phone):base(phone)
        {
            _phone = phone;
        }

        public override void Print()
        {
            base.Print();
            AddSticker();
        }

        private void AddSticker()
        {
            Console.WriteLine("Add sticker to phone !");
        }
    }
    

    /// <summary>
    /// 具体装饰（Sticker和Accessories）角色：负责给构件对象 ”贴上“附加的责任。
    /// </summary>
    public class Accessory:Decorator
    {
        private Phone _phone;

        public Accessory(Phone phone):base(phone)
        {
            _phone = phone;
        }

        public override void Print()
        {
            base.Print();

            AddAccessory();
        }

        private void AddAccessory()
        {
            Console.WriteLine("Add accessory to phone !");
        }

    }
}
