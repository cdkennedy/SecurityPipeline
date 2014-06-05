makecert.exe -r -n "CN=DevRoot" -pe -sv DevRoot.pvk -a sha1 -len 2048 -b 01/12/2010 -e 01/12/2030 -cy authority DevRoot.cer
pvk2pfx.exe -pvk DevRoot.pvk -spc DevRoot.cer -pfx DevRoot.pfx
