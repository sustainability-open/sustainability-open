How to develop the sustainability-open framework
================================================

This document contains some instructions how to develop for the sustainability-open framework. Please note that this document gives some hints about how to develop the framework itself. Component development is covered in a separate document.

Tools
-----

We are using the following tools for development:

 * IDE:              Microsoft Visual Studio 2010
 * Unit testing:     NUnit 2.6.2 
 * Version control:  Git
 * Automated builds: NAnt 0.92
 * Rhinoceros 5
 * Grasshopper 9

Some useful tools are:
 * Git for Windows (if you are into the command line), http://msysgit.github.com
 * TortoiseGit (if you are a more visual person), http://code.google.com/p/tortoisegit
 * NUnit, http://www.nunit.org
 * NANt, http://nant.sourceforge.net

Getting the code
----------------

You can get the code in the following manner on the command line:

git clone https://github.com/sustainability-open/sustainability-open

This clones the Github repository on your machine so that you can start working in your own local working copy.
You can also use TortoiseGit to clone the repository to your local machine.

Compiling the code
------------------

Make sure that you have all the prerequisites and tools installed before you start this step.

In Visual Studio you can simply compile the code.

In NAnt run the nant.bat in the nant/ directory to compile the code. The result can be found in nant/build/.

Running the test suite
----------------------

You can run the test suite in different ways:

 * Run "nant test" in the nant/ directory from the command line to run the nant build and let nant build and run the test suite.
 * Run "runtests.bat" from the command line in the src/tests/ directory to run the nunit-console
 * Open the SustainabilityOpenTests.nunit file in the src/tests/ directory to run the test suite in nunit gui

Development guidelines
----------------------

We follow the Github Flow guidelines: http://scottchacon.com/2011/08/31/github-flow.html

Version control cheat sheat
---------------------------

For those of you who are not using version control with Git a lot, we have included a few commands below for you:

 * git status                Check out the status of your branch
 * git branch -la            List all available branches
 * git branch <branchname>   Creates a new branch. Please give the branches meaningfull names, lowercases and dashed, like so: new-arabic-documentation
 * git checkout <branchname> Switch to a different branch
 * git merge <branchname>    Merge the branch to the branch you are currently working on
 * git commit -m "<message>" Commits the code
 * git push origin master    Pushes the code to Github
 * git pull                  Pulls the code from Github

You might want to read the Github documentation too: https://help.github.com/articles/set-up-git
Take a look at this resource too: https://help.github.com/articles/what-are-other-good-resources-for-using-git-or-github

Troubleshooting
---------------

NAnt on Windows 7
You might want to take a look at this link when you are using NAnt on Windows 7:
http://stackoverflow.com/questions/8605122/how-do-i-resolve-configuration-errors-with-nant-0-91
