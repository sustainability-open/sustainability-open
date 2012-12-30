How to develop your own extensions for the sustainability-open framework
------------------------------------------------------------------------

This document contains some instructions how to develop your own extensions for the sustainability-open framework. Please note that there is a seperate document that covers development for the framework itself.

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

Setup step-by-step guide
------------------------

This step-by-step guide assumes that you are using Visual Studio. 

 1. To start a new extension for sustainability-open, open a new solution in Visual Studio.
 2. Choose a class library
 3. Add the following dll files to your references:
  * sustainability-open framework
 4. For Grasshopper extensions include the following references:
  * GH_IO.dll
  * Grasshopper.dll
  * RhinoCommon.dll 
 5. Make sure that you set the "Copy Local" field to false for each of these references.
 6. The first thing you probably want to do is write some designer, analysis or assessment. Implement the SODesigner, SOAnalysis or SOAssessment class to make your own. The method you want to override is called RunDesigner(), RunAnalysis or RunAssessment.
 6. Probably the other thing you want to do is making components for Grasshopper. Implement the SODesigner_Component, SOAnalysis_Component or SOAssessment_Component to do this. Don't forget to call a method's base when overriding a method so that its parent gets executed. 
 7. And start writing your code...
