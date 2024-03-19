#region SingletonDeclaration 
    private static GameManager instance;
    public static GameManager FindInstance()
    {
        return instance; //that's just a singleton as the region says
    }

    void Awake() //this happens before the game even starts and it's a part of the singleton
    {
        if (instance != null && instance != this)
        {
            Destroy(this);
        }
        else if (instance == null)
        {
            //DontDestroyOnLoad(this);
            instance = this;
        }
    }
    #endregion