PortableDnsProxy - A Portable DNS Proxy

I developed this when in need for a software which could override DNS entries for dedicated clients without elevated rights on the clients nor access to their DNS server. So basically, this is throw away software. Please take that into account when judging the code ;-)

Configure PortableDnsProxy

Port

This is the port on which PortableDnsProxy will listen to requests and serve them well.
Typically, you can leave this value untouched. 
If you need to change it, set it to a valid port number between 1 and 65535.
It is not recommended to set it to port numbers below or equal to 1024, as they are reserved for 
special purposes and this action needs elevated priviledges (admin rights) on many systems.

some sanity checks etc missing due to speed

Hosts

Please specify one or more hosts which DNS entries you would like to see overridden.

If you do not like to use this feature, simply specify "localhost" => "127.0.0.1", as
PortableDnsProxy needs at least one entry to work and this most probably won't bother you.


PortableDnsProxy stores your configuration within your registry. 
You can remove all traces PortableDnsProxy left on your system by removing all hosts from the configuration screen.


Configure Your Browser (no admin rights needed)

Chrome
Condition	Explanation
http://peter.sh/experiments/chromium-command-line-switches/
--proxy-server ⊗	Uses a specified proxy server, overrides system settings. This switch only affects HTTP and HTTPS requests. ↪

Firefox
http://www.wikihow.com/Enter-Proxy-Settings-in-Firefox

Internet Explorer
Install one of the above.

Attribution

- Benton Stark for his excellent .Net.Proxy lib
- The folks from Fat Cow hosting for their awesome icon library 
  http://www.fatcow.com/free-icons
- The free-icons.com team for the application icon

License

                      PHILS LICENSE
	            Version 0, December 1998
             Philipp Lehmann, sayhi@phil.to

0. This is open source software. It comes without any 
   warranty, to the extent permitted by applicable law.

1. You can freely copy, redistribute, modify and use it 
   under the terms of this license as long as you release 
   your changes under this same license and your use
   cases are in no way related to military or intelligence
   activities and you do not commercially resell this
   software by itself or as part of a bigger software
   system.

2. If you are not allowed to use this software freely
   due to the aforementioned restrictions, you may try
   to contact the author for special licences.