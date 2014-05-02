if test -n "$1"
then
    PORT=$1
else
    PORT=8889
fi
BUF=--buf
python3 -m speedclue $BUF --port $PORT --count 5 \
    ../ClueSharp/ClueStick/bin/Debug/ClueStick.exe\
    ./simpleai.py\
    ./simpleai.py\
    ./simpleai.py
