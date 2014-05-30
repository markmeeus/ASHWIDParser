ASHWIDParser
============

A simple parser to parse the byte[] returned from  HardwareIdentification.GetPackageSpecificToken

Use Like This:
-------------
```cs
var components = ASHWIDParser.ParseBytes(HardwareIdentification.GetPackageSpecificToken(null).Id.ToArray());
```
