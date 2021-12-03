1- execute in .Docker ``` sudo docker build -t doevida-db .```
2- execute container
``` docker run -d -p 3306:3306 -e MYSQL_ROOT_PASSWORD=123456 -e MYSQL_DATABASE=doevida doevida-db```
3- entry in db  ``` docker exec -it container_id bash
                    mysql -uroot -p ```