FROM o19s/quepid:latest

COPY . .

ENV EMAIL=your@email.com
ENV HOST=http://localhost:3000
CMD ["sh", "-c", "echo $EMAIL && echo $HOST && ./init.sh $EMAIL $HOST"]