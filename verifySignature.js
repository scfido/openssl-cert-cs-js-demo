const crypto = require('crypto');
const fs = require('fs');

function generateSignature(keyFile, dataFile) {
  const key = fs.readFileSync(keyFile, "utf8");
  const data = fs.readFileSync(dataFile, "binary");
  const sign = crypto.createSign('RSA-SHA256');
  sign.write(data);
  sign.end();
  const signature = sign.sign({ key: key, passphrase: '' }, 'base64');
  console.log(signature);

  return signature
}

function verifySignature(crtFile, signature, dataFile) {
  const cert = fs.readFileSync(crtFile, "utf8");
  const data = fs.readFileSync(dataFile, "binary");
  const verify = crypto.createVerify('RSA-SHA256');
  verify.write(data);
  verify.end();
  const isVerified = verify.verify(cert, signature, 'base64');
  console.log(isVerified);
}

// 生成这两个函数的测试代码
// 测试 generateSignature 函数
const signature = generateSignature('./app.key', './logo.png');

// 测试 verifySignature 函数
verifySignature('./app.crt', signature, './logo.png');