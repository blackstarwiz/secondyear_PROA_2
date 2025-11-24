from ubuntu:latest

workdir /app
copy . .

run apt update
run apt install nodejs npm -y
run npm install
expose 3000
cmd ["nodejs", "hello.js"]