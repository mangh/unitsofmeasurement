/*******************************************************************************

    Units of Measurement for C# applications

    Copyright (C) Marek Aniola

    This program is provided to you under the terms of the license
    as published at https://github.com/mangh/unitsofmeasurement


********************************************************************************/
using System;
using System.IO;
using System.Collections.Generic;
using Microsoft.VisualStudio.TemplateWizard;

namespace Man.UnitsOfMeasurement
{
    public class TemplateWizard : IWizard
    {
        // Runs custom wizard logic before opening an item in the template.
        public void BeforeOpeningFile(EnvDTE.ProjectItem projectItem) { }

        // Runs custom wizard logic when a project has finished generating.
        public void ProjectFinishedGenerating(EnvDTE.Project project) { }

        // Runs custom wizard logic when a project item has finished generating.
        public void ProjectItemFinishedGenerating(EnvDTE.ProjectItem projectItem) { }

        // Runs custom wizard logic when the wizard has completed all tasks.
        public void RunFinished() { }

        // Runs custom wizard logic at the beginning of a template wizard run.
        public void RunStarted(
            object automationObject,
            Dictionary<string, string> replacementsDictionary,
            WizardRunKind runKind,
            object[] customParams)
        {
            replacementsDictionary.Add("$parserhintpath$", Path.GetDirectoryName(this.GetType().Assembly.Location));
        }

        // Indicates whether the specified project item should be added to the project.
        // This method is only called for item templates, not for project templates.
        public bool ShouldAddProjectItem(string filePath)
        {
            return true;
        }
    }
}