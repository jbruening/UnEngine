UnEngine
========

a clone of the UnityEngine.dll - so you can write and test scripts outside of unity

Usage
=====

There are three build configurations - Debug, Release, and UnityTest  
Debug - compiles builds in UnEngine namespace and as UnEngine.dll - used for unit tests  
UnityTest - same as Debug, but outputs dll to the Plugins directory in the UnityComparisonTests unity project  
Release - builds the dlls using same namespace and assembly name as UnityEngine.dll, so that no changes will have to be done in the referencing project

How to use in your project
-----
Make a Release build, and then reference the DLL's bin/Release dll. In your project, do not have the dll's be copied on output, and do not copy them into your unity projects that use your dlls

Things to note: When you reference the Release dll, make sure the reference does not have anything more than the dll name - make sure that it doesn't use the GUID, version, etc.


Running Unity comparison tests
------
Switch the solution configuration to UnityTest - this will cause the project to output to the UnityComparisonTests unity project, where there are test scripts and scenes set up
Some of the tests, like the Vector3 tests, register themselves to a new component menu named Tests, and can be run from there.
