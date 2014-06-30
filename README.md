pushbullet
==========

SINTAX


    note
            pushBullet.exe /k [Token] /d [device_id] /n ["title"+"body"]

    link
            pushBullet.exe /k [Token] /d [device_id] /l ["title"+"url"+"body"]

    address
            pushBullet.exe /k [Token] /d [device_id] /a ["name"+"address"]

    list
            pushBullet.exe /k [Token] /d [device_id] /u ["title"+"item1","item2","item3"....]

    file
            pushBullet.exe /k [Token] /d [device_id] /f ["fileAbsolutePath"+"mime"+"body"]

    ispy
    This option post to pushbullet the last accessed jpg file in folderSearch
            pushBullet.exe /k [Token] /d [device_id] /ispy ["folderSearch"+"body"]

    list devices
            pushBullet.exe /k [Token] /list all

    Do not write "[" "]". You can find "Device_id" string using command /list all at the property "iden"
