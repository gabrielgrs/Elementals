using UnityEngine;

public class PlayerService {

    public int verifyLevel(int _exp) {
        if (_exp < 5) return 1;
        if (_exp < 11) return 2;
        if (_exp < 15) return 3;
        if (_exp < 27) return 4;
        if (_exp < 43) return 5;
        if (_exp < 71) return 6;
        if (_exp < 115) return 7;
        if (_exp < 186) return 8;
        if (_exp < 301) return 9;

        return -1;
    }
}