//   Copyright © 2015 by Comodo Group Inc.
//  
//  Permission is hereby granted, free of charge, to any person obtaining a copy
//  of this software and associated documentation files (the "Software"), to deal
//  in the Software without restriction, including without limitation the rights
//  to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
//  copies of the Software, and to permit persons to whom the Software is
//  furnished to do so, subject to the following conditions:
//  
//  The above copyright notice and this permission notice shall be included in
//  all copies or substantial portions of the Software.
//  
//  THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
//  IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
//  FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
//  AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
//  LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
//  OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN
//  THE SOFTWARE.
//  
//  

using System;
using System.Collections.Generic;
using Goedel.Protocol;
using PHB.Apps.Lurk;

namespace PHB.Apps.Lurk.Server {

    /// <summary>
    /// Abstract interface to a service that supports the MeshPortal API calls.
    /// Mostly for useful in test code where the ability to switch between a
    /// direct and indirect portal connection is desirable. 
    /// </summary>
    public abstract class LurkPortal {

        /// <summary>
        /// Return a MeshService object for the named portal service.
        /// </summary>
        /// <param name="Portal">Address of the portal service.</param>
        /// <returns>Mesh service object for API access to the service.</returns>
        public virtual LurkService GetService(string Portal) {
            return GetService(Portal, null);
            }

        /// <summary>
        /// Return a MeshService object for the named portal service.
        /// </summary>
        /// <param name="Portal">Address of the portal service.</param>
        /// <param name="Account">Account name.</param>
        /// <returns>Mesh service object for API access to the service.</returns>
        public abstract LurkService GetService(string Portal, string Account);

        /// <summary>
        /// May be set to the default MeshPortal by a calling application.
        /// </summary>
        public static LurkPortal Default;

        /// <summary>
        /// May be set to the default MeshService by a calling application.
        /// </summary>
        public LurkService LurkServiceClient;
        }


    /// <summary>
    /// Abstract interface to a local service provider.
    /// </summary>
    public abstract class LurkLocalPortal : LurkPortal{
        /// <summary>
        /// File name for local access to the mesh store.
        /// </summary>
        protected string MeshStore = "mesh.jlog";

        /// <summary>
        /// File name for local access to the portal store.
        /// </summary>
        protected string PortalStore = "portal.jlog";

        /// <summary>
        /// The service name (default to mesh.prismproof.org)
        /// </summary>
        protected string ServiceName = "mesh.prismproof.org";

        /// <summary>
        /// The local PublicMeshServiceHost.
        /// </summary>
        public PublicLurkServiceProvider LurkServiceHost;
        }


    /// <summary>
    /// Direct connection to service provider via API calls. 
    /// </summary>
    public class LurkPortalDirect: LurkLocalPortal {

        /// <summary>
        /// Create new portal using the default stores.
        /// </summary>
        public LurkPortalDirect () {
            Init(ServiceName, MeshStore, PortalStore);
            }

        /// <summary>
        /// Create a new portal using the specified stores.
        /// </summary>
        /// <param name="ServiceName">DNS service name</param>
        /// <param name="MeshStore">File name for the Mesh Store.</param>
        /// <param name="PortalStore">File name for the Portal Store.</param>
        public LurkPortalDirect(string ServiceName, string MeshStore, string PortalStore) {
            Init(ServiceName, MeshStore, PortalStore);
            }

        /// <summary>
        /// Create a new portal using the specified stores.
        /// </summary>
        /// <param name="MeshStore">File name for the Mesh Store.</param>
        /// <param name="PortalStore">File name for the Portal Store.</param>
        public LurkPortalDirect(string MeshStore, string PortalStore) {
            Init(ServiceName, MeshStore, PortalStore);
            }

        /// <summary>
        /// Initialize the portal
        /// </summary>
        /// <param name="ServiceName"></param>
        /// <param name="MeshStore"></param>
        /// <param name="PortalStore"></param>
        protected void Init (string ServiceName, string MeshStore, string PortalStore) {
            this.ServiceName = ServiceName;
            this.MeshStore = MeshStore;
            this.PortalStore = PortalStore;
            LurkServiceHost = new PublicLurkServiceProvider(ServiceName, MeshStore, PortalStore);
            }

        /// <summary>
        /// Return a MeshService object for the named portal service.
        /// </summary>

        public override LurkService GetService(string Portal, string Account) {
            var Session = new DirectSession(null);
            LurkServiceClient = new PublicLurkService(LurkServiceHost, Session);
            return LurkServiceClient;
            }

        }






    /// <summary>
    /// Direct connection to service provider via JSON encoding, decoding and dispatch.
    /// Useful for producing documentation and for testing.
    /// </summary>
    public class LurkPortalLocal : LurkLocalPortal {

        /// <summary>
        /// Create new portal using the default stores.
        /// </summary>
        public LurkPortalLocal() {
            //MeshServiceHost = new PublicMeshServiceProvider(ServiceName, MeshStore, PortalStore);
            }

        /// <summary>
        /// Return a MeshService object for the named portal service.
        /// </summary>
        public override LurkService GetService(string Service, string Account) {
            //var Session = new LocalRemoteSession(MeshServiceHost, ServiceName, Account);
            //MeshServiceClient = new MeshServiceClient(Session);
            return LurkServiceClient;
            }

        }

    /// <summary>
    /// Connection to network service using HTTP client.
    /// </summary>
    public class MeshPortalRemote : LurkPortal {

        /// <summary>
        /// Default constructor.
        /// </summary>
        public MeshPortalRemote () {

            }


        /// <summary>
        /// Return a MeshService object for the named portal service.
        /// </summary>
        public override LurkService GetService(string Service, string Account) {
            var URI = JPCProvider.WellKnownToURI(Service, LurkService.WellKnown,
                        LurkService.Discovery, false, true);

            //var Session = new WebRemoteSession(URI, Service, Account);
            //MeshServiceClient = new MeshServiceClient(Session);
            return LurkServiceClient;
            }
        }

    }
