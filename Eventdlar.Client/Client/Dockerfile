FROM node:latest as build
WORKDIR /app
COPY package.json ./


COPY . .
RUN npm run build --prod




FROM nginx:latest as prod

RUN rm -rf /usr/share/nginx/html/*
COPY ./nginx.conf /etc/nginx/nginx.conf
COPY --from=build app/dist/Client /usr/share/nginx/html

CMD [ "nginx", "-g", "daemon off;" ]