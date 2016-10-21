# DataExtractor

Filters, orders and groups the given data and transforms it into Excel sheets with diagrams
The source file must be a CSV with the following column order (without headers!):

| UUID                     | Timestamp     | Room  / Waypoint Name | Phone Name | Mac Adress        | Distance |
|--------------------------|---------------|-----------------------|------------|-------------------|----------|
| 580796c6ea039b21fb734c06 | 1476892358679 | E219                  | Phone1     | 44:a1:d9:57:55:6f | 22,81    |
| 580796c6ea039b21fb734c06 | 1476892358679 | E219                  | Phone1     | 44:a1:d9:57:80:3f | 12,88    |
| 5807970eea039b21fb734c3e | 1476892430014 | E217                  | Phone2     | 44:a1:d9:70:a8:c0 | 4,33     |
| etc.                     | etc.          | etc.                  | etc.       | etc.              | etc.     |

## Run

Execute the the DataExtractor.exe in the command line and pass the file without path (must be in the same directory) as the first argument.
 ```shell
$ DataExtractor.exe VS.csv
```

Excel sheets will be created in the same folder.
Additional files will then be created in subfolders.