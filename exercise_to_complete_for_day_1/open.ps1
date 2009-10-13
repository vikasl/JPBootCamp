properties{
  $third_party_dir = "thirdparty"
  $test_driven_key = "Registry::HKEY_LOCAL_MACHINE/SOFTWARE/MutantDesign/TestDriven.Net/TestRunners"
  $mbunit_key = "$test_driven_key/MbUnit"
  $mbunit_key_exists = test-path -path $mbunit_key
}


task update_test_driven{
  if (test-path $test_driven_key)
  {
    if ($mbunit_key_exists -eq $false)
    {
      new-item -path $mbunit_key
    }
    "Updating TestDriven.Net to point at local mbunit install"
    set-itemproperty -path $mbunit_key -name "Application" "$third_party_dir\mbunit\MbUnit.GUI.exe"
    set-itemproperty -path $mbunit_key -name "AssemblyPath" "$third_party_dir\mbunit\MbUnit.AddIn.dll"
    set-itemproperty -path $mbunit_key -name "TargetFrameworkAssemblyName" "MbUnit.Framework"
    set-itemproperty -path $mbunit_key -name "TypeName" "MbUnit.AddIn.MbUnitTestRunner"
    "Updated TestDrivent.Net to point at local mbunit install"
  }
}


