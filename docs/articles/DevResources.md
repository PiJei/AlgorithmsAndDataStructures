## Coding Protocol

1. Before starting to code, make sure the task is tracked on [Issues](https://github.com/PiJei/CSFundamentalAlgorithms/issues) or [Kanban board](https://github.com/PiJei/CSFundamentalAlgorithms/projects/1#column-5181891). 

    * For minor changes navigate to the [Issues](https://github.com/PiJei/CSFundamentalAlgorithms/issues) tab, and check to see whether the issue you want to address is already listed. If not list it and assign it to yourself. 

    * For implementing new algorithms or data structures navigate to the [Kanban board](https://github.com/PiJei/CSFundamentalAlgorithms/projects/1#column-5181891), and check to see whether the feature you want to implement is listed under any of the columns. If not add it under [ToDo column](https://github.com/PiJei/CSFundamentalAlgorithms/projects/1#column-5181891), and assign it to yourself. Once the implementation is complete and the feature is merged in with the master branch add it to the [Content page](https://github.com/PiJei/CSFundamentalAlgorithms/wiki/Content). 

    * Other than that you can also pick existing items in the [Issues](https://github.com/PiJei/CSFundamentalAlgorithms/issues) or [ToDo column](https://github.com/PiJei/CSFundamentalAlgorithms/projects/1#column-5181891) in the [Kanban board](https://github.com/PiJei/CSFundamentalAlgorithms/projects/1#column-5181891), or add new items.

1. When the work item is documented and tracked:
    1. On your local machine, clone this repository: 
 
            git clone https://github.com/PiJei/CSFundamentalAlgorithms.git

    1. Create a new local branch: 

            git checkout -b dev/{username}/{feature}. 

      _Be aware that direct pushes to the master branch are prevented by default._ 
    1. When your implementation is complete and it is ready for a code review push your local branch to the repository: 

            git push --set-upstream origin dev/{username}/{feature}. 

    1. Navigate to your branch via GitHub API and create a pull request. 
    1. Once your pull request is reviewed/approved and you have addressed all the comments, squash and merge it with the master branch. 

# Coding guidelines
* Coding standards for this repository are moderated via [.editorconfig](https://github.com/PiJei/CSFundamentalAlgorithms/blob/master/.editorconfig) file at the root directory.

* Our recommended IDE is [Visual Studio latest version (2019 as of this writing)](https://docs.microsoft.com/en-us/visualstudio/install/install-visual-studio?view=vs-2019). 

* Every ***.cs** file should start with the License Header. If using Visual Studio, install [License Header Manager](https://marketplace.visualstudio.com/items?itemName=StefanWenig.LicenseHeaderManager). For guidelines on how to use this extension see [here](https://github.com/rubicon-oss/LicenseHeaderManager/wiki). 

* To name unit test follow standards [here](https://docs.microsoft.com/en-us/dotnet/core/testing/unit-testing-best-practices), or briefly follow this pattern: {Name of the method being tested}\_{What is being tested}\_{Expected behavior}.

* For other naming conventions follow [Microsoft General Naming Conventions](https://docs.microsoft.com/en-us/dotnet/standard/design-guidelines/general-naming-conventions). 

* Make sure to provide XML documentation for all the methods and their parameters using [XML documentation features](https://docs.microsoft.com/en-us/dotnet/csharp/codedoc). The repository also uses [DocFx](https://dotnet.github.io/docfx/) for generating readable documentation. Install DocFx, and run `docfx .\docfx_project\docfx.json --serve .\docfx_project\_site\` , to visit the site locally, navigate to `http://localhost:8080`. 

* Any new algorithm and data structure implementation should be decorated with time and space complexity attributes, and should be completely tested by adding unit tests. 
