How to develop the sustainability-open framework
================================================

This document contains some instructions how to develop for the sustainability-open framework. Please note that this document gives some hints about how to develop the framework itself. Component development is covered in a separate document.

Tools
-----

We are using the following tools for development:

 * IDE:              Microsoft Visual Studio 2010
 * Unit testing:     NUnit
 * Version control:  Git
 * Automated builds: NAnt 0.92
 * Rhinoceros 5
 * Grasshopper

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

Compiling the code
------------------

Make sure that you have all the prerequisites and tools installed before you start this step.

Version control
---------------

For those of you who are not using version control with Git a lot, we have included a few commands below for you:

 * git branch -la            List all available branches
 * git branch <branchname>   Creates a new branch. Please give the branches meaningfull names, lowercases and dashed, like so: new-arabic-documentation
 * git merge <branchname>    Merge the branch to the branch you are currently working on

Troubleshooting
---------------

NAnt on Windows 7
You might want to take a look at this link when you are using NAnt on Windows 7:
http://stackoverflow.com/questions/8605122/how-do-i-resolve-configuration-errors-with-nant-0-91
