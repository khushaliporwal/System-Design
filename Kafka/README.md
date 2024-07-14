This project covers, how producer and consumer works using kafka.
To run this project:
1. Start Producer
2. Start consumers (one or more)
3. Post msg from PostMan or swagger

**Result:
![image](https://github.com/user-attachments/assets/038f2997-e9a9-4a09-ad90-0ff92fdcc776)


For Kafka installtion : Docker confluent kafka image is used
Commands to start and run kafka:
[folder where docker-compose file exists]\docker-compose -f docker-compose.yml up -d 
To check status : docker ps
![image](https://github.com/user-attachments/assets/bae0cf86-f90b-43cd-bff8-acff73648e67)

Kafka control center UI:
![image](https://github.com/user-attachments/assets/de043386-2f48-4a05-8866-5f4e6bd67c73)

To Add topic or change partition: we can do either from code or from UI
![image](https://github.com/user-attachments/assets/ea18997f-2919-4af3-bf8f-a59674ee46fa)


