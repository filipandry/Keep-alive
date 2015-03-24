# Keep-alive
Keep alive one or more websites


Keep alive is a windows service used to ping an Url periodically.
It work with MS Sql Server DB.

You can configure one or more websites to ping.

The solution has 5 projects:
  1. Keep alive - the windows service that ping the websites
  2. Keep alive DB Setup - a windows form that allow to cofigure the database
  3. Keep alive configurator - a windows form that allow to setup the links to ping
  4. Crypto - a dll with a helper class for encryption and decryption of string used to encrypt/decrypt the configuration file
  5. Setup - an Install Shield project
