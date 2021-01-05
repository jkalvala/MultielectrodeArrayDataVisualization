# 1. MultielectrodeArrayDataVisualization (developed in C#)
As part of my PhD thesis work, I collected multi-electrode array recordings(time-series) from dissociated hippocampal cell cultures from Sprague Dawley rats using a tool provided by Multichannelsystems (MCS). Although the MCS tool was useful for collecting the raw neuronal activity data, I wanted to visualize these time-series signals captured from different electrodes. Therefore  I developed my own data visualization tool in csharp using APIs provided from Multichannel systems.

OUTPUT:
1) All the "Form" objects (eg Form1.cs, frmFileExport.cs) along with the functionality were created by me to visualize the data. The functionality developed include, visualizing the raw data from all electrodes, aligned in time, filtering the data, detecting spikes that cross a certain threshold (which correspond to neuronal spiking activity), visualizing data in different time resolution windows (2 secs, 10 sec, 30 secs, 10 mins, 60 mins etc).


![Visualization1_MultiElectrodeArrayRecordings](https://user-images.githubusercontent.com/50377837/103706122-2c626500-4f61-11eb-9153-3275c7e16a21.png)
![Visualization2_SoftwareFunctionality](https://user-images.githubusercontent.com/50377837/103706131-308e8280-4f61-11eb-9cec-54498a1f2bd1.png)
