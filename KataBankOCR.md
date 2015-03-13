My solution to the KataBankOCR exercise at [codingdojo](http://codingdojo.org/cgi-bin/wiki.pl?KataBankOCR).

# Problem description #
The input contains one or more ocr codes. Each code consist of three lines with 27 characters.<br />
For instance;
```
    _  _     _  _  _  _  _
  | _| _||_||_ |_   ||_||_|
  ||_  _|  | _||_|  ||_| _| 
```
Should produce the following output;
```
123456789
```
If some digit in an ocr could not be parsed, for instance;
```
   _ 
  |_|
  |_
```
That digit is represented by a ? in the output and that ocr is marked with the suffix ILL.
```
22845?165 ILL
```
Every ocr must be checked with a check sum algorithm and if the code fails to pass it is marked with ERR.
```
228456165 ERR
```
# Solution #
The problem was solved using [test driven development](http://en.wikipedia.org/wiki/Test-driven_development).

The focus was on simplicity and readability rather than efficiency.

The problem was solved using five classes.
## Scanner ##
The Scanner is responsible for creating a StringReader for reading the input and it uses a ScannerResultBuilder to read the codes one at the time until there is no more input.
```
        public string Scan()
        {
            using (var reader = new StringReader(input))
            {
                var result = new ScannerResultBuilder(reader);
                while (!reader.EOF())
                    result.ReadOCR();
                return result.GetResult();
            }
        }
```
## ScannerResultBuilder ##
When the ScannerResultBuilder is told to read on ocr code it reads three lines from the input and use theese lines to create an OCR object. The OCR object is responsible for converting the input and the result is appended to the output of the builder.
```
        public void ReadOCR()
        {
            string ocrAsString = GetNextOCR().ToString();
            if (reader.EOF())
                result.Append(ocrAsString);
            else
                result.AppendLine(ocrAsString);
        }
```

## OCR ##
The OCR object gets three lines of input representing an OCR code. From the input it creates 9 instances of the Digit class that does the actual conversion. I also uses a CheckSumValidator to validate the input using the 9 digits.
```
        private void Parse()
        {
            for (int index = 0; index < 9; index++)
                digits.Add(GetDigit(index));
        }
        
        public Digit GetDigit(int index)
        {
            const int DIGIT_WIDTH = 3;
            return new Digit(
                line0.Substring(index * DIGIT_WIDTH, DIGIT_WIDTH) +
                line1.Substring(index * DIGIT_WIDTH, DIGIT_WIDTH) +
                line2.Substring(index * DIGIT_WIDTH, DIGIT_WIDTH));
        }
```
## Digit ##
The Digit class does the actual conversion of the digits. It gets input of the form;
```
string digit7 =
    " _ " +
    "  |" +
    "  |";
```
And uses a really simple method to convert the "digits" to characters;
```
        public char ToChar()
        {
            int code = input.GetHashCode();
            switch (code)
            {
                case 485846108:
                    return '0';
                case 1865122982:
                    return '1';
                case -1445372811:
                    return '2';
                case 900428925:
                    return '3';
                case -1441827709:
                    return '4';
                case -1610386307:
                    return '5';
                case 338779185:
                    return '6';
                case 1824294056:
                    return '7';
                case 485841969:
                    return '8';
                case -1463323523:
                    return '9';

            }
            return '?';
        }
```
## CheckSumValidator ##
The name of the class is pretty self explanatory and a description of the algorithm can be found at the [codingdojo](http://codingdojo.org/cgi-bin/wiki.pl?KataBankOCR) page.

My complete solution with tests can be found [here](http://code.google.com/p/danoncodekatas/source/browse/#svn/trunk/KataBankOCR)