﻿using NTMiner.MinerClient;
using System;
using System.Windows.Input;

namespace NTMiner.Vms {
    public class LocalIpViewModel : ViewModelBase, ILocalIp {
        private string _settingID;
        private string _name;
        private string _dHCPServer;
        private bool _dHCPEnabled;
        private bool _isAutoDNSServer;
        private IpAddressViewModel _iPAddressVm;
        private IpAddressViewModel _iPSubnetVm;
        private IpAddressViewModel _defaultIPGatewayVm;
        private IpAddressViewModel _dNSServer0Vm;
        private IpAddressViewModel _dNSServer1Vm;

        public ICommand Save { get; private set; }

        public LocalIpViewModel(ILocalIp data) {
            _settingID = data.SettingID;
            _name = data.Name;
            _dHCPServer = data.DHCPServer;
            _dHCPEnabled = data.DHCPEnabled;
            if (data.DefaultIPGateway == data.DNSServer0) {
                _isAutoDNSServer = true;
            }
            else {
                _isAutoDNSServer = false;
            }
            _iPAddressVm = new IpAddressViewModel(data.IPAddress);
            _iPSubnetVm = new IpAddressViewModel(data.IPSubnet);
            _defaultIPGatewayVm = new IpAddressViewModel(data.DefaultIPGateway);
            _dNSServer0Vm = new IpAddressViewModel(data.DNSServer0);
            _dNSServer1Vm = new IpAddressViewModel(data.DNSServer1);
            this.Save = new DelegateCommand(() => {
                VirtualRoot.LocalIpSet.SetIp(this, this.IsAutoDNSServer);
                TimeSpan.FromSeconds(3).Delay().ContinueWith(t => {
                    VirtualRoot.LocalIpSet.Refresh();
                });
            });
        }

        public string SettingID {
            get => _settingID;
            set {
                _settingID = value;
                OnPropertyChanged(nameof(SettingID));
            }
        }

        public string Name {
            get { return _name; }
            set {
                _name = value;
                OnPropertyChanged(nameof(Name));
            }
        }

        public string DefaultIPGateway {
            get => DefaultIPGatewayVm.AddressText;
        }

        public IpAddressViewModel DefaultIPGatewayVm {
            get => _defaultIPGatewayVm;
            set {
                _defaultIPGatewayVm = value;
                OnPropertyChanged(nameof(DefaultIPGatewayVm));
            }
        }

        public string DHCPEnabledGroupName1 {
            get {
                return this.SettingID + 1;
            }
        }

        public string DHCPEnabledGroupName2 {
            get {
                return this.SettingID + 2;
            }
        }

        public string DHCPEnabledGroupName3 {
            get {
                return this.SettingID + 3;
            }
        }

        public string DHCPEnabledGroupName4 {
            get {
                return this.SettingID + 4;
            }
        }

        public bool DHCPEnabled {
            get => _dHCPEnabled;
            set {
                if (_dHCPEnabled != value) {
                    _dHCPEnabled = value;
                    OnPropertyChanged(nameof(DHCPEnabled));
                    if (!value) {
                        IsAutoDNSServer = false;
                    }
                }
            }
        }

        public string DHCPServer {
            get => _dHCPServer;
            set {
                _dHCPServer = value;
                OnPropertyChanged(nameof(DHCPServer));
            }
        }

        public string IPAddress {
            get => IPAddressVm.AddressText;
        }

        public IpAddressViewModel IPAddressVm {
            get => _iPAddressVm;
            set {
                _iPAddressVm = value;
                OnPropertyChanged(nameof(IPAddressVm));
            }
        }

        public string IPSubnet {
            get { return IPSubnetVm.AddressText; }
        }

        public IpAddressViewModel IPSubnetVm {
            get => _iPSubnetVm;
            set {
                _iPSubnetVm = value;
                OnPropertyChanged(nameof(IPSubnetVm));
            }
        }

        public string DNSServer0 {
            get => DNSServer0Vm.AddressText;
        }

        public IpAddressViewModel DNSServer0Vm {
            get => _dNSServer0Vm;
            set {
                _dNSServer0Vm = value;
                OnPropertyChanged(nameof(DNSServer0Vm));
            }
        }

        public string DNSServer1 {
            get => DNSServer1Vm.AddressText;
        }

        public IpAddressViewModel DNSServer1Vm {
            get => _dNSServer1Vm;
            set {
                _dNSServer1Vm = value;
                OnPropertyChanged(nameof(DNSServer1Vm));
            }
        }

        public bool IsAutoDNSServer {
            get => _isAutoDNSServer;
            set {
                if (_isAutoDNSServer != value) {
                    _isAutoDNSServer = value;
                    OnPropertyChanged(nameof(IsAutoDNSServer));
                }
            }
        }
    }
}
