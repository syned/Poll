using System;
using System.Web.Mvc;
using PollProject.Models;

namespace PollProject.Binders
{
    public class QuestionViewModelBinder : DefaultModelBinder
    {
        public override object BindModel(ControllerContext controllerContext, ModelBindingContext bindingContext)
        {
            var newBindingContext = bindingContext;
            Type modelType = bindingContext.ModelType;

            if (modelType == typeof(QuestionViewModel))
            {
                var format = string.Format("{0}.Type", bindingContext.ModelName);
                var type = bindingContext.ValueProvider.GetValue(format).AttemptedValue;

                if (type == typeof(TextQuestionViewModel).Name)
                    modelType = typeof(TextQuestionViewModel);
                else if (type == typeof(SingleSelectionQuestionViewModel).Name)
                {
                    modelType = typeof(SingleSelectionQuestionViewModel);
                }
                else if (type == typeof(MultiSelectionQuestionViewModel).Name)
                {
                    modelType = typeof(MultiSelectionQuestionViewModel);
                }

                var modelMetadata = ModelMetadataProviders.Current.GetMetadataForType(() => bindingContext.Model, modelType);

                newBindingContext = new ModelBindingContext()
                {
                    ModelMetadata = modelMetadata,
                    ModelState = bindingContext.ModelState,
                    PropertyFilter = bindingContext.PropertyFilter,
                    ValueProvider = bindingContext.ValueProvider,
                    ModelName = bindingContext.ModelName
                };
            }

            return base.BindModel(controllerContext, newBindingContext);
        }
    }
}