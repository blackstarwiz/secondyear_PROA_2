FROM node:alpine
WORKDIR /app
COPY notes .
RUN npm install
EXPOSE 5173
CMD [ "npm", "run", "dev" ]
