using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using Forge.Forms;
using Forge.Forms.Controls;
using Forge.UI.Interfaces;
using Forge.UI.Models;

namespace Forge.UI.Wpf
{
    public class WpfParser : IParser
    {
        private IParserContext Context { get; set; }

        public object Parse(IParserContext context)
        {
            Context = context;
            Context.PossibleActions.AddAction(new ResetAction());

            var instance = Activator.CreateInstance(ClassBuilder.BuildFromContext(context));
            var dForm = new DynamicForm {Model = instance, Context = this};
            dForm.OnAction += DFormOnOnAction;
            var toReturn = new List<UIElement> {dForm};
            return toReturn;
        }
        
        public class ResetAction : IAction
        {
            public string Key { get; } = "reset";
            public Action<object[]> Action { get; } = DoAction;

            private static void DoAction(object[] obj)
            {
                ModelState.Reset(obj[0]);
            }
        }

        private void DFormOnOnAction(object sender, ActionEventArgs e)
        {
            if (e.ActionContext.Action is string key && Context.PossibleActions.ContainsKey(key))
            {
                Context.PossibleActions[key].LastOrDefault()?.Action.Invoke(new []{ e.ActionContext.Model });
            }
        }
    }
}