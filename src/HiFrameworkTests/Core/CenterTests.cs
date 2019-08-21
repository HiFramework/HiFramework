﻿using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace HiFramework.Tests
{
    [TestClass()]
    public class CenterTests
    {
        [TestMethod]
        public void TestInit()
        {
            var binder = new NewBinder();
            Center.Init(binder);
        }

        [TestMethod]
        public void TestBinder()
        {
            var binder = new NewBinder();
            Center.Init(binder);
            Center.Get<INewComponent>();
            Center.Get<INewComponent>();//reget
            Assert.IsTrue(Center.IsComponentExist<INewComponent>());
            Center.Dispose();
            Center.Remove<INewComponent>();
            Assert.IsFalse(Center.IsComponentExist<INewComponent>());
        }

        [TestMethod]
        public void TestDispose()
        {
            Center.Dispose();
        }

        public class NewBinder : Binder
        {
            public override void Init()
            {
                Bind<INewComponent>().To<NewNewComponent>();
            }
        }

        public interface INewComponent
        {

        }

        public class NewNewComponent : ComponentBase, INewComponent
        {
            public override void OnCreated()
            {
            }

            public override void OnDestroy()
            {
            }
        }
    }
}