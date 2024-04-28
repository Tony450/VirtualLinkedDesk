# **VirtualLinkedDesk**

## About VirtualLinkedDesk

VirtualLinkedDesk is a remote desktop program that lets you control a machine from a distance as if you were in front of it. There are a lot of applications that are capable of doing this function, but what is the most powerfull characteristic that this program has that others don't? The fact that it is very simple and easy to understand if you have intermediate level programming knowledge.

Do you like technology? Are you a curious person who likes knowing how things in general work? Then, you will love this program. Remote desktop technology has left its footprint since computing first appeared, and nowadays, it continues evolving in different types of functionalities like Airplay, Chrome Cast, Windows 365, etc. From this moment on, you will have the possibility of understanding this technology if you download the source code of this program, it is very exciting, isn't it?. So, I invite you to do it, I hope you enjoy using it and seeing its structure as much as I have.

This is the program that I created from scratch for my Computer Science Engineering Bachelor thesis. The corresponding document is [TFG_Antonio_Manuel_Hernandez_DeLeon_2021.pdf](Thesis/TFG_Antonio_Manuel_Hernandez_DeLeon_2021.pdf).

## Installation

### Installer file

Installing the program by downloading an installer is very easy. You only have to go to [Releases](/release/latest) section and download the latest published version. When download finishes, you have to follow the installer steps like any other application.

<!-- https://docs.github.com/es/github/administering-a-repository/releasing-projects-on-github/linking-to-releases -->


### Building from source

You will need the following things to build and use this software:

- Two Machines with Microsoft Windows installed
- Visual Studio 2019 (v16.8.0 or newer)
- .NET 5.0 SDK

Once you have everything prepared you have to follow the next steps:

1. Clone repository using Visual Studio 2019.
2. Build BitmapLibrary project to let other projects use its output.
3. Build Client or Server project depending on which program you will use on the current machine.
4. Repeat the previous steps on the other machine, this time building the project that you want to run on this machine.

<!-- Proyectos: Prometheus, windows_exporter, VS Code, Telegram, VLC, Gimp, VNC -->

<!-- Enlace a Github Wiki o MD para instrucciones de compilación -->


<!-- ## Usage -->

<!-- Instrucciones de uso en un futuro https://docs.github.com/es/communities/documenting-your-project-with-wikis/editing-wiki-content -->

## License

Copyright (C) Antonio Manuel Hernández De León.

Licensed under the [GPL license](LICENSE.txt).

Logo icon made by [Freepik](https://www.flaticon.com/authors/freepik) from [www.flaticon.com](https://www.flaticon.com/).
