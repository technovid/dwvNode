var dwv = require('dwv');
var fs = require('fs');

// read DICOM file
var data = fs.readFileSync('C:\\Users\\techn\\Downloads\\dicom_viewer_0015\\0015.dcm');
// convert data to array buffer
var arrayBuffer = new Uint8Array(data).buffer;
// parse
var dicomParser = new dwv.dicom.DicomParser();
dicomParser.parse(arrayBuffer);
// wrapped tags
var tags = dicomParser.getDicomElements();
// log
console.log(tags.getFromName('PatientName'));