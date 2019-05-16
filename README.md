# MultielectrodeArrayDataVisualization (developed in C#)
As part of my PhD thesis work, I collected multi-electrode array recordings(time-series) from dissociated hippocampal cell cultures from Sprague Dawley rats using a tool provided by Multichannelsystems (MCS). However the data visualization from this MCS tool was very basic and did not meet my project needs. Therefore  I developed my own data visualization tool in csharp using APIs provided from Multichannel systems.

All the "Form" objects (eg Form1.cs, frmFileExport.cs) along with the functionality were created by me to visualize the data. The functionality developed include, visualizing the raw data from all electrodes, aligned in time, filtering the data, detecting spikes that cross a certain threshold (which correspond to neuronal spiking activity), visualizing data in different time resolution windows (2 secs, 10 sec, 30 secs, 10 mins, 60 mins etc).

Also included are the screenshots of the final desktop application that was created to visualize multi electrode arrays and to perform analysis such as filtering, spike detection etc.
