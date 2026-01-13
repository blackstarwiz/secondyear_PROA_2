from node:alpine

workdir /app
copy . .

run npm ci

expose 3000

cmd ["nodejs", "hello.js"]