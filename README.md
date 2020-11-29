# IViR
Simple C# Windows tool for doing a HTTP request to IndigoVision (and other) type CCTV cameras. The URL configured works for IndigoVision in my testing. HIKVision and other brand cameras will need a different URL.

This tool was built in Visual Studio 2019 (Version 16.8.2) using .NET Framework 4.7.2

Fundamentally this tool will:
1. Connect to the URL configured using HTTP (not RTSP or ONVIF),
2. Authenticate using Digest Authentication,
3. Grab the image from that URL,
4. Save a copy of that file in the Application StartUp path as ddMMyyyy-HHmmss.png thus ensuring no two images are the same,
5. Display the image in the pictureBox control at 640x480 with zoom set to fill the box.

It has no error checking in it but will show some level of logging as it processes each request. Note that some cameras can take 10 to 20 seconds to process the GET request depending on the image resolution, WiFi connection speed etc.

Credit to https://uxwing.com/license/ for the completely free icon file https://uxwing.com/cctv-camera-icon/ 
