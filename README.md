## How would you build a URL shortener?  - System Design

An easy-to-use yet effective tool for reducing lengthy URLs to shorter, easier-to-manage ones is a URL shortener. This is especially helpful for sharing links on character-limited platforms or for enhancing user experience by clearing clutter. Bitly and TinyURL are two well-known URL shorteners.

# Functionalities
1.	Generate a Code that is unique for a given long url
2.	Redirect users to the orinial url using Code (from 1)


# Steps to Create

1.	The endpoint accepts a Url, Validates if it is an absolute url
2.	Create a shortUrl based on the Maximum length set by you and the Alphabets set by you in code
3.	Save the ShortUr and return it to the client
4.	For redirection, Find the long url using shorturl Code 
5.	Redirect the client to original url

