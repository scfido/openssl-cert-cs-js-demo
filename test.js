const crypto = require("crypto");
const fs = require("fs");

const privateKey = fs.readFileSync("./app.key", "utf8");
const data = "Hello world";

const sign = crypto.createSign("SHA256");
sign.update(data);
sign.end();
const signature = sign.sign(privateKey, "base64");

console.log(signature);

// JS:
// CNwNy/d6k57pwEY29hOHmy7cNa5twhT144zh0mzuPynjedjv913nHgCJfkLf4d
// zDsaXz0eVZN8ZbQiRhryFmVJjqL/K0KmUtL2ULEJq3E3Nx+8WfY1+CRdzso5dffEg
// XOyvDC7Xg8cAJWflRVjFHdo7PQmM81oXg4tE0ExHUyHWwAL2aosDMKK20fkzrwDH3
// zzLpUqDkq7EFtcKaqrsNnlxkIVuTGSdd+bJIrHH7YuTjlC2y7ipLXjcVzy4t3wbGK
// zDjoDUZb5phJOL2DgsNtlL1iA1JyMIyolP2GrIhK7j1iXOabkeKFdTcUvLN+bMlEi
// ihNvD1q28MVbJrlCvuLA==

// CS:
// CNwNy/d6k57pwEY29hOHmy7cNa5twhT144zh0mzuPynjedjv913nHgCJfkLf4d
// zDsaXz0eVZN8ZbQiRhryFmVJjqL/K0KmUtL2ULEJq3E3Nx+8WfY1+CRdzso5dffEg
// XOyvDC7Xg8cAJWflRVjFHdo7PQmM81oXg4tE0ExHUyHWwAL2aosDMKK20fkzrwDH3
// zzLpUqDkq7EFtcKaqrsNnlxkIVuTGSdd+bJIrHH7YuTjlC2y7ipLXjcVzy4t3wbGK
// zDjoDUZb5phJOL2DgsNtlL1iA1JyMIyolP2GrIhK7j1iXOabkeKFdTcUvLN+bMlEi
// ihNvD1q28MVbJrlCvuLA==