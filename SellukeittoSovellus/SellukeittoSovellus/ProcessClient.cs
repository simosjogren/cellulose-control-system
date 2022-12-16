using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Tuni.MppOpcUaClientLib;

namespace SellukeittoSovellus
{
    /// <summary>
    /// Data structure used for storing process values
    /// </summary>
    public struct Data
    {
        /// <summary>
        /// Variable containing LI100 data
        /// </summary>
        public int LI100;

        /// <summary>
        /// Variable containing LI200 data
        /// </summary>
        public int LI200;

        /// <summary>
        /// Variable containing PI300 data
        /// </summary>
        public int PI300;

        /// <summary>
        /// Variable containing TI300 data
        /// </summary>
        public double TI300;

        /// <summary>
        /// Variable containing LI400 data
        /// </summary>
        public int LI400;

        /// <summary>
        /// Variable containing LS+300 data
        /// </summary>
        public bool LSplus300;

        /// <summary>
        /// Variable containing LS-300 data
        /// </summary>
        public bool LSminus300;
    }
    
    /// <summary>
    /// Class for handeling communication with process
    /// </summary>
    class ProcessClient
    {

        #region CONSTANTS

        private const bool CONNECTED = true;
        private const bool DISCONNECTED = false;
        private const string CLIENT_URL = "opc.tcp://127.0.0.1:8087";

        #endregion


        #region OBJECTS

        /// <summary>
        /// Client for communicating with process
        /// </summary>
        public MppClient mMppClient;

        private ConnectionParamsHolder mConnectionParamsHolder;

        private Logger logger = new Logger();

        #endregion


        #region VARIABLES

        /// <summary>
        /// Client connection state
        /// </summary>
        public bool mConnectionState = DISCONNECTED;

        /// <summary>
        /// Process data
        /// </summary>
        public Data mData = new Data();

        #endregion


        //###########################

        /// <summary>
        /// Constructor for class
        /// </summary>
        public ProcessClient()
        {
            mConnectionParamsHolder = new ConnectionParamsHolder(CLIENT_URL);
            ConnectOPCUA();
        }

        /// <summary>
        /// Tries to establish connection to process
        /// </summary>
        /// <returns></returns>
        public bool ConnectOPCUA()
        {
            try
            {
                mMppClient = new MppClient(mConnectionParamsHolder);

                mMppClient.ConnectionStatus += new MppClient.ConnectionStatusEventHandler(ConnectionStatus);
                mMppClient.ProcessItemsChanged += new MppClient.ProcessItemsChangedEventHandler(ProcessItemsChanged);

                mMppClient.Init();

                addSubscriptions();

                mConnectionState = CONNECTED;

                return true;
            }
            catch (Exception ex)
            {
                logger.WriteLog(ex.Message);

                return false;
            }
        }

        // Add subsriptions to process devices
        private bool addSubscriptions()
        {
            try
            {
                // Tanks
                mMppClient.AddToSubscription("LI100");
                mMppClient.AddToSubscription("LI200");
                mMppClient.AddToSubscription("PI300");
                mMppClient.AddToSubscription("TI300");
                mMppClient.AddToSubscription("LI400");

                //Sensor
                mMppClient.AddToSubscription("LS+300");
                mMppClient.AddToSubscription("LS-300");
            
                return true;
            }
            catch (Exception ex)
            {
                logger.WriteLog(ex.Message);

                return false;
            }
        }


        #region EVENTS

        // Event for connection status changes
        private void ConnectionStatus(object source, ConnectionStatusEventArgs args)
        {
            try
            {
                mConnectionState = (args.StatusInfo.FullStatusString == "Connected");
            }
            catch (Exception ex)
            {
                logger.WriteLog(ex.Message);
            }
        }

        // Event for process values changed
        private void ProcessItemsChanged(object source, ProcessItemChangedEventArgs args)
        {
            try
            {
                foreach (KeyValuePair<String, MppValue> item in args.ChangedItems)
                {
                    switch (item.Key)
                    {
                        case "LI100":
                            mData.LI100 = (int)item.Value.GetValue();
                            break;
                        case "LI200":
                            mData.LI200 = (int)item.Value.GetValue();
                            break;
                        case "PI300":
                            mData.PI300 = (int)item.Value.GetValue();
                            break;
                        case "TI300":
                            mData.TI300 = (double)item.Value.GetValue();
                            break;
                        case "LI400":
                            mData.LI400 = (int)item.Value.GetValue();
                            break;
                        case "LS+300":
                            mData.LSplus300 = (bool)item.Value.GetValue();
                            break;
                        case "LS-300":
                            mData.LSminus300 = (bool)item.Value.GetValue();
                            break;
                        default:
                            logger.WriteLog("ERROR: ProcessItemsChanged item " + item.Key + " not handeled");
                            break;
                    }
                }
            }
            catch (Exception ex)
            {
                logger.WriteLog(ex.Message);
            }
        }

        #endregion

    }
}
