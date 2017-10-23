# W8HHF DSTAR CHECK FOR NEW USERS HELPER
#
# The following 2 programs are run on another machine that connects to the W8HHF D-Star Gateway
# via a secure shell and downloads the w8hhf_dstar_users_new.txt file that's created.
#
# The C# program then parses this text file and determines what to do.
#
# Login via SSH key to check for new users, then process file with mono app
#
#
5 * * * * /usr/bin/scp -P 2222 AAAAA@BBBBB.dstargateway.org:/home/AAAAA/w8hhf_dstar_users_new.txt /home/AAAAA/public_html
7 * * * * /usr/bin/mono /home/AAAAA/scripts/w8hhf/dstar/NewDStarUsersCheckAndSendEmail.exe
