const crypto = require('crypto');
const fs = require('fs');
const forge = require('node-forge');

function verifyCertificate() {
  const caCert = fs.readFileSync('./ca.crt', "utf8");
  const appCert = fs.readFileSync('./app.crt', "utf8");

  const pki = forge.pki;
  const caCertObj = pki.certificateFromPem(caCert);
  const appCertObj = pki.certificateFromPem(appCert);

  const caStore = pki.createCaStore([caCertObj]);
  const verificationResult = pki.verifyCertificateChain(caStore, [appCertObj]);

  console.log(verificationResult);
}

verifyCertificate();