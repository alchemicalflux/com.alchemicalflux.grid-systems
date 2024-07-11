/*------------------------------------------------------------------------------
  File:           SampleEditorTestsScript.cs 
  Project:        YourProjectName  # You should replace this with your project name
  Description:    YourDescription  # You should replace this with your description
  Copyright:      ©2024 YourName/YourCompany. All rights reserved.  # You should replace this with your copyright details

  Last commit by: alchemicalflux 
  Last commit at: 2024-07-11 13:28:52 
------------------------------------------------------------------------------*/
using NUnit.Framework;
using System.Collections;
using UnityEngine.TestTools;

namespace AlchemicalFlux.GridSystems.Editor.Tests
{
    public class SampleEditorTestsScript
    {
        // A Test behaves as an ordinary method
        [Test]
        public void NewTestScriptSimplePasses()
        {
            // Use the Assert class to test conditions
        }

        // A UnityTest behaves like a coroutine in Play Mode. In Edit Mode you can use
        // `yield return null;` to skip a frame.
        [UnityTest]
        public IEnumerator NewTestScriptWithEnumeratorPasses()
        {
            // Use the Assert class to test conditions.
            // Use yield to skip a frame.
            yield return null;
        }
    }
}