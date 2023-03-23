# 简介

本示例演示了
- 使用openssl创建CA和APP两个证书
- 使用CA公钥验证APP证书链的合法性
- 使用APP私钥签名数据
- 使用APP公钥验证签名
- 使用 JavaScript和C#两种语言演示

# 演示

- JavaScript
```sh
pnpm i
node verifyCertificate.js
node verifySignature.js
```

- C#
```sh
dotnet run
```

## 验证

通过`test.js`和`test.cs`两个文件输出对比，对同样的输入生成的签名是一致的。如果不一致请检查你输入的数据是否一致，比如读取文件的方式不同等。

```txt
JS:
CNwNy/d6k57pwEY29hOHmy7cNa5twhT144zh0mzuPynjedjv913nHgCJfkLf4d
zDsaXz0eVZN8ZbQiRhryFmVJjqL/K0KmUtL2ULEJq3E3Nx+8WfY1+CRdzso5dffEg
XOyvDC7Xg8cAJWflRVjFHdo7PQmM81oXg4tE0ExHUyHWwAL2aosDMKK20fkzrwDH3
zzLpUqDkq7EFtcKaqrsNnlxkIVuTGSdd+bJIrHH7YuTjlC2y7ipLXjcVzy4t3wbGK
zDjoDUZb5phJOL2DgsNtlL1iA1JyMIyolP2GrIhK7j1iXOabkeKFdTcUvLN+bMlEi
ihNvD1q28MVbJrlCvuLA==
```

```txt
CS:
CNwNy/d6k57pwEY29hOHmy7cNa5twhT144zh0mzuPynjedjv913nHgCJfkLf4d
zDsaXz0eVZN8ZbQiRhryFmVJjqL/K0KmUtL2ULEJq3E3Nx+8WfY1+CRdzso5dffEg
XOyvDC7Xg8cAJWflRVjFHdo7PQmM81oXg4tE0ExHUyHWwAL2aosDMKK20fkzrwDH3
zzLpUqDkq7EFtcKaqrsNnlxkIVuTGSdd+bJIrHH7YuTjlC2y7ipLXjcVzy4t3wbGK
zDjoDUZb5phJOL2DgsNtlL1iA1JyMIyolP2GrIhK7j1iXOabkeKFdTcUvLN+bMlEi
ihNvD1q28MVbJrlCvuLA==
```txt

## 注意

C#代码在我的电脑上`dotnet run`会报错，但是以调试方式运行时正常的。
