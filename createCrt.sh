# 使用自己颁发的CA根证书签发一个应用证书，应用证书名为app.crt。生成使用openssl生成这些证书的shell脚本
#!/bin/bash

# 生成CA根证书的私钥
openssl genrsa -out ca.key 2048

# 生成CA根证书的证书签名请求
openssl req -new -key ca.key -out ca.csr

# 自签名CA根证书
openssl x509 -req -in ca.csr -signkey ca.key -out ca.crt -days 365 -sha256

# 生成应用证书的私钥
openssl genrsa -out app.key 2048

# 生成应用证书的证书签名请求
openssl req -new -key app.key -out app.csr

# 使用CA根证书签发应用证书
openssl x509 -req -in app.csr -CA ca.crt -CAkey ca.key -CAcreateserial -out app.crt -days 365 -sha256

# 使用CA根证书验证应用证书
openssl verify -CAfile ca.crt app.crt

# 将应用证书转换为CSPK#12格式，C#需要这个格式的证书
openssl pkcs12 -export -out app.pfx -inkey app.key -in app.crt