# MultielectrodeArrayDataVisualization (developed in C#)
As part of my PhD thesis work, I collected multi-electrode array recordings(time-series) from dissociated hippocampal cell cultures from Sprague Dawley rats using a tool provided by Multichannelsystems (MCS). Although the MCS tool was useful for collecting the raw neuronal activity data, I wanted to visualize these time-series signals captured from different electrodes. Therefore  I developed my own data visualization tool in csharp using APIs provided from Multichannel systems.

Shown below are snapshots of this dektop GUI based application.The functionality developed include, visualizing the raw data from all electrodes, aligned in time, filtering the data, detecting spikes that cross a certain threshold (which correspond to neuronal spiking activity), visualizing data in different time resolution windows (2 secs, 10 sec, 30 secs, 10 mins, 60 mins etc).

## Main application window
<img width="800" alt="MeaTimeAlignedChannels" src="https://user-images.githubusercontent.com/50377837/103706937-92032100-4f62-11eb-9547-d4fff3993dd2.PNG">

## Demonstration of functionality to detect neuronal spikes (steps include high pass filtering raw signals and detecting signal that is 6*std_devn below mean)
<img width="800" alt="MEAReviewerSpikeDetection" src="https://user-images.githubusercontent.com/50377837/103706905-7dbf2400-4f62-11eb-880c-e04bb4dc65f2.PNG">

## Highlighting the functionality built into the tool
<img width="800" alt="SoftwareFunctionality" src="https://user-images.githubusercontent.com/50377837/103707125-f8883f00-4f62-11eb-8167-51730a17b2fa.PNG">

