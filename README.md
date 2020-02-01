# Introduction 
DBFood is a web application split into two sites.
The first, AdminSite, is created using Web Forms while the PublicSite is made in MVC.

# Getting Started
Due to the nature and innate "flaw" of historically tracked changes( simply put commits of progress on Azure ), some components aren't added into the mentioned commits.
After Visual Studio tells you to sync the packages( and you do so ), the solution won't be able to initialize because the sync was incomplete.

The following package has to be reinstalled through NuGet Package manager: Microsoft.CodeDom.Providers.DotNetCompilerPlatform

After it was reinstalled, the project should initialize properly.

