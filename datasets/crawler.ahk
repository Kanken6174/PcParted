#NoEnv  ; Recommended for performance and compatibility with future AutoHotkey releases.
; #Warn  ; Enable warnings to assist with detecting common errors.
SendMode Input  ; Recommended for new scripts due to its superior speed and reliability.
SetWorkingDir %A_ScriptDir%  ; Ensures a consistent starting directory.
a::

UrlPart1 := "https://duckduckgo.com/?q="
UrlPart2 := "&iax=images&ia=images"
rawIn := ""
toScrap := "names.NVIDIA.pnm" ;put your term file here
endIndex := 249 ; where to end (line)
scrapIndex := 1 ;put where to start (line)
oldTerm := nani ;anything as long as it's not the first line of the nameset

FileReadLine, rawIn, %toScrap%, %scrapIndex%
termToSearch := sanitizeInput(rawIn)

while(endIndex >= scrapIndex){
ToolTip, Progression:`n %scrapIndex%/%endIndex%, 100, 150
run, %UrlPart1%%termToSearch%%UrlPart2%
	while(true){
		PixelGetColor, color, 52, 124
		if(color == 0x161616){
		break
		}
		sleep 100
	}
sleep 1000
Click, 82 272
sleep 500
Click, 616 539
sleep 750
Click, 427 62
send, ^a
sleep 50
send, ^c
sleep 50
result := Clipboard
FileAppend, %result%`n, scrapped.txt
send ^w ^w
scrapIndex++
oldTerm := termToSearch

FileReadLine, rawIn, %toScrap%, %scrapIndex%
termToSearch := sanitizeInput(rawIn)

}

sanitizeInput(Rawin){
termToSearch := RegExReplace(rawIn,"\t.*","")
termToSearch := RegExReplace(termToSearch,"\+","%2B")
termToSearch := RegExReplace(termToSearch,"\s","+")
termToSearch := RegExReplace(termToSearch,"\,","%2C")
termToSearch := RegExReplace(termToSearch,"\/","%2F")
termToSearch := RegExReplace(termToSearch,"=","%3D")
return %termToSearch%
}

