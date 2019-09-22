FROM node:latest as build
WORKDIR /app
COPY package.json ./
COPY ngix.conf /etc/nginx/nginx.conf

COPY . .
RUN npm run build --prod




FROM nginx:latest as prod

RUN rm -rf /usr/share/nginx/html/*

COPY --from=build app/dist/Client /usr/share/nginx/html

CMD [ "nginx", "-g", "daemon off;" ]