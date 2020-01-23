docker build -t new-mood-api-image .

docker tag new-mood-api-image registry.heroku.com/new-mood-api/web

docker push registry.heroku.com/new-mood-api/web

heroku container:release web -a new-mood-api