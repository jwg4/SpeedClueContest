if test -n "$1"
then
    PORT=$1
else
    PORT=8889
fi
BUF=--buf
python3 -m speedclue $BUF --port $PORT --count 5 \
    ../ClueSharp/CluePaddle/bin/Debug/CluePaddle.exe\
    ../ClueSharp/ClueStick/bin/Debug/ClueStick.exe\
    ../ClueSharp/ClueBat/bin/Debug/ClueBat.exe
