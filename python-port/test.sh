if test -n "$1"
then
    PORT=$1
else
    PORT=8889
fi
BUF=--buf
python3 -m speedclue $BUF --port $PORT --count 5 \
    ../ClueSharp/ClueBot/bin/Debug/ClueBot.exe\
    ./simpleai.py\
    ./simpleai.py\
    ./simpleai.py
