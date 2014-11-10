# PortableDnsProxy
### A Portable HTTP Proxy and DNS Redirector

When in need for a software which could redirect HTTP requests meant for one server to another server during 
a infrastucture switch (comparable of using your production domain with your test environment), 
I downloaded the entire internet but found zero solutions.

[A self portrait.](http://cdn.grumpycats.com/wp-content/uploads/2013/01/Grumpy-Cat-01.jpg)

The only option which I could think of is an HTTP proxy (which one can set in portable Browsers also within corporate environments) 
which would to the redirection based on a ruleset. 

Et voila - maybe someone finds this helpful.

PortableDnsProxy supports chunked HTTP requests as well as TLS. For connecting via TLS, self signed intermediate certificates are being created and cached on the fly. 
So when connecting to an HTTPS server, you will probably need to accept the "unsafe certificate" within your browser on the first visit.

You can clear the TLS certificate cache within the configuration screen, but then all nasty certificate warnings will reappear.

## Configure PortableDnsProxy

### Port of Portable DNS Proxy's proxy

This is the port on which Portable DNS Proxy will listen to your requests and serve them well.
Typically, you can leave this value untouched. 
If you need to change it, set it to a valid port number between 1 and 65535.
It is not recommended to set it to port numbers below or equal to 1024, as they are reserved for 
special purposes and this action needs elevated priviledges (admin rights) on many systems.

### Proxy for outgoing request (host:port)

Here you can specify your (coorporate) proxy server if Portable DNS Proxy needs that to communicate to the Internet.

### Hosts

Please specify one or more hosts which DNS entries you would like to see tampered with. 

You can independently from each other define 

  - a host/IP to which requests will be redirected to instead of the original host based on your systems DNS settings
  - a new hostname which will replace the original hostname within your HTTP request headers.

If you leave a field blank, that action is not being performed (no redirection and/or no rewriting).

## Configure Your Browser (no admin rights needed)

### Firefox
An instruction with screenshots can be found [here](http://www.wikihow.com/Enter-Proxy-Settings-in-Firefox).

### Chrome

Chrome based on it's Chromium foundation offers several [command line switches](http://peter.sh/experiments/chromium-command-line-switches/). One of these switches is:

Condition | Explanation
------------- | -------------
--proxy-server | Uses a specified proxy server, overrides system settings. This switch only affects HTTP and HTTPS requests.

### Internet Explorer
Install one of the above.

## Attribution

- Benton Stark for his excellent .Net.Proxy lib (http://www.starksoft.com/)
- The folks from Fat Cow hosting for their awesome icon library (http://www.fatcow.com/free-icons)
- The free-icons.com team for the application icon (http://free-icons.com)

## License

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
