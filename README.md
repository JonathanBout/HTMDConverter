# HTMDConverter
HTMDConverter converts Markdown to HTML, although the Markdown is maybe not perfect.
I tweaked it to how I like it best, which is very easy by changing the Regexes in the main script.
## Current support
At the moment the full list of supported Markdown items is as follows:
- Heading 1 to 3
- **bold**, *italic* and ***both***
- > blockquotes
- ordered lists
- unordered lists
- (single line) `code blocks`
It's not a lot, but it will grow soon, I think.  
---
## Testing the converter
To test it, just execute the test project. This will open up a console window that gives the following options:
### a line of Markdown
(use with `l`)
This allows you to enter a line of Markdown, and then converts it to HTML.
#### Example
```markdown
>**Hello** *World*!
```
gives
```html
<blockquote><b>Hello</b> <i>World</i>!</blockquote>
```
### a Markdown file
(use with `f`)
This allows you to enter the path to a Markdown file. By default, this gets printed to the console.  
By adding `>>>` after the link to the markdown file you can add an output file.
#### Example
```bash
path\to\your\file.md >>> path\to\your\output\file.html
```
