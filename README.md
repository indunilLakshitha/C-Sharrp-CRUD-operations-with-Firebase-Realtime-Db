# C-Sharrp-CRUD-operations-with-Firebase-Realtime-Db
CRUD operations with images 

## Create a firebase account and open a new project

install **FireSharp.Serialization.JsonNet** package

## Get Auth secret 

```
go to the firebase project -> project overview ->SERVICE ACCOUNTS -> database secrets -> secret
```


```
IFirebaseConfig config = new FirebaseConfig
        {
            AuthSecret = "lJ00CGCubk8WK0tl0zD2ZUULDmVkUfVA1fXqqs0V",
            BasePath = "https://c-sharp-2a4aa.firebaseio.com/"
        };
```

###IcCoBoDe
